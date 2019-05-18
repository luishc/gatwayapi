using System;

public class Transaction
{
    public decimal ValorLiquido { get; set; }

    MdrRepository repository = new MdrRepository();

    public Transaction(TransactionDTO transaction)
    {
        CalcularTransacao(transaction);
    }

    private void CalcularTransacao(TransactionDTO transaction)
    {
        try
        {
            decimal discount = repository.GetDiscount(transaction.Adquirente, transaction.Bandeira, transaction.Tipo);
            this.ValorLiquido = transaction.Valor - 
                ((transaction.Valor * discount) / 100);
        } catch (Exception)
        {
            throw;
        }
        
    }
}