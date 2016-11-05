
namespace PizzaManagement.Notification
{
    /// <summary>
    /// The InstantMessenger interface
    /// </summary>
    interface IBridgeNotifier
    {
        /// <summary>
        /// Sets the service.
        /// </summary>
        /// <param name="service">The service.</param>
        void SetService(IMessenger service);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        void SendMessage(string message);
    }
}
