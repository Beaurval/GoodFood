namespace goodfood_user.Exeptions
{
    public class PasswordDoesNotMatchException : Exception
    {
        public PasswordDoesNotMatchException()
        {

        }

        public PasswordDoesNotMatchException(string message)
        {

        }

        public PasswordDoesNotMatchException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
