using PizzaManagement.ViewModels;

namespace PizzaManagement.Notification
{
    public class BridgeNotifier : IBridgeNotifier
    {
        private IMessenger _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BridgeNotifier"/> class.
        /// </summary>
        /// <param name="clientViewModel">The client view model.</param>
        public BridgeNotifier(ClientViewModel clientViewModel)
        {
            _service = new EmailMessenger(clientViewModel);
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SendMessage(string message)
        {
            _service.SendMessage(message);
        }

        /// <summary>
        /// Sets the service.
        /// </summary>
        /// <param name="service">The service.</param>
        public void SetService(IMessenger service)
        {
            _service = service;
        }
    }
}
