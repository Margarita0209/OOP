namespace OOPLab14
{
    public partial class Program
    {

        [System.Runtime.Serialization.DataContract]
        [System.Serializable]


        public class Book    // абстр класс Book
        {
            [System.Runtime.Serialization.DataMember]
      
            // название книги
     
            public string BookName { get; set; }
            [System.Runtime.Serialization.DataMember]
   
            // жанр книги
        
            public string Genre { get; set; }
            [System.Runtime.Serialization.DataMember]
       
            // автор книги
       
            public string Author { get; set; }

            public Book() { }     // стандар констр без парам

        }

    }
}
