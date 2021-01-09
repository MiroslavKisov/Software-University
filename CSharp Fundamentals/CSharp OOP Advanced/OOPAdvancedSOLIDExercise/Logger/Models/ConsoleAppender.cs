using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Models
{
    public class ConsoleAppender : IAppender
    {
        private SimpleLayout simpleLayout;
        private XmlLayout xmlLayout;

        public string ReportLevel { get; set; }

        public XmlLayout XmlLayout
        {
            get { return xmlLayout; }
            set { xmlLayout = value; }
        }

        public SimpleLayout SimpleLayout
        {
            get { return simpleLayout; }
            set { simpleLayout = value; }
        }

        public string LayoutType { get; set; }

        public ConsoleAppender(SimpleLayout simpleLayout)
        {
            this.SimpleLayout = simpleLayout;
            this.LayoutType = nameof(this.SimpleLayout);
            this.ReportLevel = null;
        }

        public ConsoleAppender(XmlLayout xmlLayout)
        {
            this.XmlLayout = xmlLayout;
            this.LayoutType = nameof(this.XmlLayout);
            this.ReportLevel = null;
        }

        public string AppendMessage(string message)
        {
            if (this.XmlLayout == null)
            {
                StringBuilder sb = new StringBuilder();
                var messageArgs = GetArgs(message);
                sb.AppendFormat(SimpleLayout.SetFormat(messageArgs), messageArgs[0], messageArgs[1], messageArgs[2]);
                return sb.ToString();
            }
            else if (this.SimpleLayout == null)
            {
                StringBuilder sb = new StringBuilder();
                var messageArgs = GetArgs(message);
                sb.AppendFormat(XmlLayout.SetFormat(messageArgs), messageArgs[0], messageArgs[1], messageArgs[2]);
                return sb.ToString();
            }
            return "";
        }

        private string[] GetArgs(string message)
        {
            var messageArgs = message.Split('|');
            return messageArgs;
        }
    }
}