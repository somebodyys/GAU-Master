namespace homework_4;


public abstract class BankAccount
{
    protected double balance;

    protected BankAccount(double initialBalance)
    {
        balance = initialBalance;
    }

    public abstract void Deposit(double amount);

    public abstract void Withdraw(double amount);

    public double CheckBalance()
    {
        return balance;
    }
}