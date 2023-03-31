namespace MoneyCorpUITesting.PageObjects
{
    public interface IPageActions
    {
        public abstract IPageActions NavigateTo();
        public abstract void EnsurePageLoaded();
        public abstract void EnsurePageLoadedWithWait(TimeSpan? waitTimeSpan = null);
        public abstract bool IsPageLoaded(int? timeout = null);
    }
}