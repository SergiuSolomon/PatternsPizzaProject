using PizzaManagement.ViewModels;

namespace PizzaManagement.Notification
{
    /// <summary>
    /// The Email messenger class
    /// </summary>
    /// <seealso cref="PizzaManagement.Notification.IMessenger" />
    public class EmailMessenger : IMessenger
    {
        private ClientViewModel _clientViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailMessenger"/> class.
        /// </summary>
        /// <param name="clientViewModel">The client view model.</param>
        public EmailMessenger(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel;
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SendMessage(string message)
        {
            _clientViewModel.EmailMessage = message;
        }
    }
}
