using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class Message
    {

        public Message(string text)
        {
            this.Text = text;
        }

        public string Text { get; set; }
    }
}
