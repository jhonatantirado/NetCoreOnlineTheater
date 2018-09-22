namespace NewOnlineTheater.Customer.Domain.Entity
{
    using System;

    public class Customer: BaseEntity
    {
        private string _name;
        public virtual CustomerName Name
        {
            get => (CustomerName)_name;
            set => _name = value;
        }

        private readonly string _email;
        public virtual Email Email => (Email)_email;

        public virtual CustomerStatus Status { get; protected set; }

        private decimal _moneySpent;
        public virtual Dollars MoneySpent
        {
            get => Dollars.Of(_moneySpent);
            protected set => _moneySpent = value;
        }

        protected Customer()
        {
        }

        public Customer(CustomerName name, Email email) : this()
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _email = email ?? throw new ArgumentNullException(nameof(email));

            MoneySpent = Dollars.Of(0);
            Status = CustomerStatus.Regular;
        }
    }
}
