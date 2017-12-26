namespace OOPLab14
{

    public partial class Program
    {

        [System.Runtime.Serialization.DataContract]
        [System.Serializable]
       
        public class Library : Book      // класс книга
        {
            public override string ToString() // переопр метод ToString
            {

                return $"{this.GetType()} {BookName} {Genre} {Author}";

            }

            // конструкторы объекта класса Library
            public Library()     // без парам
            {

                BookName = "Евгений Онегин";
                Genre = "Роман в стихах";
                Author = "А.С.Пушкин";

            }


            public Library(string _BookName, string _Genre, string _Author)   //с парам
            {

                BookName = _BookName;
                Genre = _Genre;
                Author = _Author;

            }

        }

    }

}
