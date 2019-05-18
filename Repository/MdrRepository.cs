using System;
using System.Collections.Generic;
using System.Linq;

public class MdrRepository
{
    private List<MerchantDiscountRates> mock =  new List<MerchantDiscountRates>
        {
            new MerchantDiscountRates
            {
                Adquirente = "Adquirente A",
                Taxas = new List<Taxa>
                {
                    new Taxa
                    {
                        Bandeira = "Visa",
                        Credito = 2.25m,
                        Debito = 2
                    },
                    new Taxa
                    {
                        Bandeira = "Master",
                        Credito = 2.35m,
                        Debito = 1.98m
                    }
                }
            },
            new MerchantDiscountRates
            {
                Adquirente = "Adquirente B",
                Taxas = new List<Taxa>
                {
                    new Taxa
                    {
                        Bandeira = "Visa",
                        Credito = 2.50m,
                        Debito = 2.08m
                    },
                    new Taxa
                    {
                        Bandeira = "Master",
                        Credito = 2.65m,
                        Debito = 1.75m
                    }
                }
            },
            new MerchantDiscountRates
            {
                Adquirente = "Adquirente C",
                Taxas = new List<Taxa>
                {
                    new Taxa
                    {
                        Bandeira = "Visa",
                        Credito = 2.75m,
                        Debito = 2.16m
                    },
                    new Taxa
                    {
                        Bandeira = "Master",
                        Credito = 3.10m,
                        Debito = 1.58m
                    }
                }
            }
        };

    public List<MerchantDiscountRates> GetAll()
    {
        return mock;
    }

    public decimal GetDiscount(string adquirente, string bandeira, string tipo)
    {
        if(tipo.ToLower() != "credito" && tipo.ToLower() != "debito")
            throw new Exception("Tipo inválido");

        var adquirenteSelecionado = mock.FirstOrDefault(x => x.Adquirente.ToLower() == adquirente.ToLower());
        
        if(adquirenteSelecionado == null)
            throw new Exception($"Adquirente {adquirente} não encontrado");

        if(adquirenteSelecionado.Taxas == null || adquirenteSelecionado.Taxas.Count <= 0)
            throw new Exception($"Adquirente {adquirente} ainda não possui taxas");

        var bandeiraSelecionada = adquirenteSelecionado.Taxas
                .FirstOrDefault(x => x.Bandeira.ToLower() == bandeira.ToLower());

        if(bandeiraSelecionada == null)
            throw new Exception($"O adquirente {adquirente} não tem a bandeira {bandeira}");

        if(tipo.ToLower() == "credito")
            return bandeiraSelecionada.Credito;
        else
            return bandeiraSelecionada.Debito;
    }
}