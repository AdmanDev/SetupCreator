namespace SetupCreator
{
    public interface IStep
    {
        bool Validate();
        void Update();
    }
}
