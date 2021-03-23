using System;
namespace BleacherYak
{
    public class GameObject
    {
        private string gameID;
        private string date;
        private string home;
        private string visitor;
        private string UTCtime;
        //private Drawable logoAway;
        //private Drawable logoHome;

        // Constructor
        public GameObject(string gameID, string date, string home, string visitor, string UTCtime)
        {
            this.gameID = gameID;
            this.date = date;
            this.home = home;
            this.visitor = visitor;
            this.UTCtime = UTCtime;
        }

        //Methods
        public string _gameID
        {
            get { return gameID; }
            set { gameID = value; }
        }

        public string _date
        {
            get { return date; }
            set { date = value; }
        }

        public string _home
        {
            get { return home; }
            set { home = value; }
        }

        public string _visitor
        {
            get { return visitor; }
            set { visitor = value; }
        }

        public string _UTCtime
        {
            get { return UTCtime; }
            set { UTCtime = value; }
        }


    }

}
