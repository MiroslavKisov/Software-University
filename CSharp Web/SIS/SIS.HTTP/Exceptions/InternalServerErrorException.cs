namespace SIS.HTTP.Exceptions
{
    using Common;
    using System;

    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException()
            :base(Messages.InternalServerErrorMessage)
        {
        }
    }
}
