using System;

namespace SetupCreator
{
    //SI TU MODIFIES CETTE STRUCT IL FAUT LA MODIFIER DANS LE NAMESPACE "SetupCreator" AUSSI
    [Serializable]
    public struct Ad
    {
        //Variables
        public string image;
        public string description;
        public string urlTitle;
        public string url;

        //Constructor
        public Ad(string _img, string _description, string _urlTitle, string _url)
        {
            image = _img;
            description = _description;
            urlTitle = _urlTitle;
            url = _url;
        }
    }
}
