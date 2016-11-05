using PizzaManagement.ViewModels;

namespace PizzaManagement.Notification
{
    public class SmsMessenger : IMessenger
    {
        private ClientViewModel _clientViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailMessenger"/> class.
        /// </summary>
        /// <param name="clientViewModel">The client view model.</param>
        public SmsMessenger(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel;
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SendMessage(string message)
        {
            _clientViewModel.SmsMessage = message;
        }
    }
}
