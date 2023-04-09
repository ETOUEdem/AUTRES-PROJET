using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Sourcing
{

    public record Person(
    string Name,
    string Address
);

    public record InvoiceInitiated(
        double Amount,
        string Number,
        Person IssuedTo,
        DateTime InitiatedAt
    );

    public record InvoiceIssued(
        string IssuedBy,
        DateTime IssuedAt
    );

    public enum InvoiceSendMethod
    {
        Email,
        Post
    }

    public record InvoiceSent(
        InvoiceSendMethod SentVia,
        DateTime SentAt
    );

    public enum InvoiceStatus
    {
        Initiated = 1,
        Issued = 2,
        Sent = 3
    }
    class Invoice
    {
        public string Id { get; set; }
        public double Amount { get; private set; }
        public string Number { get; private set; }

        public InvoiceStatus Status { get; private set; }

        public Person IssuedTo { get; private set; }
        public DateTime InitiatedAt { get; private set; }

        public string IssuedBy { get; private set; }
        public DateTime IssuedAt { get; private set; }

        public InvoiceSendMethod SentVia { get; private set; }
        public DateTime SentAt { get; private set; }


        public void When(object @event)
        {
            switch (@event)
            {
                case InvoiceInitiated invoiceInitiated:
                    Apply(invoiceInitiated);
                    break;
                case InvoiceIssued invoiceIssued:
                    Apply(invoiceIssued);
                    break;
                case InvoiceSent invoiceSent:
                    Apply(invoiceSent);
                    break;
            }
        }

        private void Apply(InvoiceInitiated @event)
        {
            Id = @event.Number;
            Amount = @event.Amount;
            Number = @event.Number;
            IssuedTo = @event.IssuedTo;
            InitiatedAt = @event.InitiatedAt;
            Status = InvoiceStatus.Initiated;
        }

        private void Apply(InvoiceIssued @event)
        {
            IssuedBy = @event.IssuedBy;
            IssuedAt = @event.IssuedAt;
            Status = InvoiceStatus.Issued;
        }

        private void Apply(InvoiceSent @event)
        {
            SentVia = @event.SentVia;
            SentAt = @event.SentAt;
            Status = InvoiceStatus.Sent;
        }
    }
}
