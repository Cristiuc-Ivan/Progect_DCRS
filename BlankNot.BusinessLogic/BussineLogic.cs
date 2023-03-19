using BlankNot.BusinessLogic.Interface;
using BlankNot.BusinessLogic;

public class BussineLogic
{
    public ISession GetSessionBL()
    {
        return new SessionBL();
    }
}