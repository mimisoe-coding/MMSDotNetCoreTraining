public class CardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public void setCardNum(string cardNum)
    {
        this.cardNum = cardNum;
    }
    public void setPin(int pin)
    {
        this.pin = pin;
    }
    public void setFirstName(string firstName)
    {
        this.firstName = firstName;
    }
    public void setLastName(string lastName)
    {
        this.lastName = lastName;
    }
    public void setBalance(double balance)
    {
        this.balance = balance;
    }
    public string getCardNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }



}
