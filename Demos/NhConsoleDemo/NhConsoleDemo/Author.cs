namespace NhConsoleDemo {
    public class Author {
        protected Author() {
        }

        public Author(string id, string first, string last, string phone, bool hasContract) {
            Id = id;
            FirstName = first;
            LastName = last;
            Phone = phone;
            HasContract = hasContract;
        }

        public virtual string Id { get; private set; }
        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }
        public virtual string Phone { get; private set; }
        public virtual bool HasContract { get; private set; }
    }
}