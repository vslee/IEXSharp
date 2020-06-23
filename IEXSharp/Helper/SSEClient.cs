using LaunchDarkly.EventSource;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace IEXSharp.Helper
{
	/// <summary> SSEClient which provides events to subscribe to and method to start streaming. IDisposable </summary>
	/// <typeparam name="T"></typeparam>
	public class SSEClient<T> : IDisposable //,IEventSource
	{
		EventSource eventSource;

		/// <summary>
		/// Initializes a new instance of the <see cref="SSEClient" /> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		/// <exception cref="ArgumentNullException">client
		/// or
		/// configuration</exception>
		public SSEClient(Configuration configuration)
		{
			eventSource = new EventSource(configuration: configuration);
			eventSource.Opened += onOpened;
			eventSource.Closed += onClosed;
			//eventSource.MessageReceived += MessageReceived;
			eventSource.MessageReceived += Evt_MessageReceived;
			eventSource.CommentReceived += onCommentReceived;
			eventSource.Error += onError;
		}

		#region Public Events
		/// <summary>
		/// Occurs when the connection to the EventSource API has been opened.
		/// </summary>
		public event EventHandler<StateChangedEventArgs> Opened;
		void onOpened(object s, StateChangedEventArgs e) => Opened?.Invoke(s, e);
		/// <summary>
		/// Occurs when the connection to the EventSource API has been closed.
		/// </summary>
		public event EventHandler<StateChangedEventArgs> Closed;
		void onClosed(object s, StateChangedEventArgs e) => Closed?.Invoke(s, e);
		///// <summary>
		///// Occurs when a Server Sent Event from the EventSource API has been received.
		///// </summary>
		//public event EventHandler<MessageReceivedEventArgs> MessageReceived;
		public event EventHandler<List<T>> MessageReceived;
		/// <summary>
		/// Occurs when a comment has been received from the EventSource API.
		/// </summary>
		public event EventHandler<CommentReceivedEventArgs> CommentReceived;
		void onCommentReceived(object s, CommentReceivedEventArgs e) => CommentReceived?.Invoke(s, e);
		/// <summary>
		/// Occurs when an error has happened when the EventSource is open and processing Server Sent Events.
		/// </summary>
		public event EventHandler<ExceptionEventArgs> Error;
		void onError(object s, ExceptionEventArgs e) => Error?.Invoke(s, e);
		#endregion Public Events

		/// <summary>
		/// Gets the state of the EventSource connection.
		/// </summary>
		/// <value>
		/// One of the <see cref="EventSource.ReadyState"/> values, which represents the state of the EventSource connection.
		/// </value>
		public ReadyState ReadyState => eventSource.ReadyState;

		/// <summary>
		/// This will block until cancelled! Initiates the request to the EventSource API and parses Server Sent Events received by the API.
		/// </summary>
		/// <returns>A <see cref="System.Threading.Tasks.Task"/> A task that represents the work queued to execute in the ThreadPool.</returns>
		/// <exception cref="InvalidOperationException">The method was called after the connection <see cref="ReadyState"/> was Open or Connecting.</exception>
		public Task StartAsync() => eventSource.StartAsync();

		/// <summary>
		/// Closes the connection to the EventSource API. The EventSource cannot be reopened after this.
		/// </summary>
		public void Close() => Dispose();

		private void Evt_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			//Log("EventSource Message Received. Event Name: {0}", e.EventName);
			//Log("EventSource Message Properties: {0}\tLast Event Id: {1}{0}\tOrigin: {2}{0}\tData: {3}",
			//	Environment.NewLine, e.Message.LastEventId, e.Message.Origin, e.Message.Data);
			var content = e.Message.Data;
			try
			{
				MessageReceived?.Invoke(this, JsonSerializer.Deserialize<List<T>>(
					content, ExecutorBase.JsonSerializerOptions));
			}
			catch (JsonException ex)
			{
				throw new JsonException(content, ex);
			}
		}

		/// <summary>
		/// Equivalent to calling <see cref="Close"/>.
		/// </summary>
		public void Dispose()
		{
			eventSource.Opened -= onOpened;
			eventSource.Closed -= onClosed;
			//eventSource.MessageReceived -= MessageReceived;
			eventSource.MessageReceived -= Evt_MessageReceived;
			eventSource.CommentReceived -= onCommentReceived;
			eventSource.Error -= onError;
			eventSource.Dispose();
		}
	}
}
