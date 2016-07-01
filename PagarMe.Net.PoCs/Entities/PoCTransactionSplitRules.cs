using Newtonsoft.Json;
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagarMe;
using PagarMe.Base;
using PagarMePoCs.Net.Interfaces;

namespace PagarMePoCs.Net.Entities
{
    public class PoCTransactionSplitRules : IPoC
    {
        Transaction model;

        public PoCTransactionSplitRules()
        {
        }

        public String Title
        { get { return "Criar Transaction Split Rules"; } }

        public void Create()
        {
            try
            {
                model = new Transaction()
                {
                    Amount = 3100,
                    PaymentMethod = PaymentMethod.CreditCard,
                    CardNumber = "4242424242424242",
                    CardHolderName = "Richard",
                    CardExpirationDate = "0921",
                    CardCvv = "123",
                    Customer = new Customer()
                    {
                        Name = "Richard",
                        DocumentNumber = "43591017833",
                        DocumentType = DocumentType.Cpf,
                        Email = "richard@pagar.me",
                        Address = new Address()
                        {
                            Zipcode = "13223030",
                            Neighborhood = "Jardim Paulistano",
                            Street = "Av. Brigadeiro Faria Lima",
                            StreetNumber = "1811"
                        },
                        Phone = new Phone()
                        {
                            Ddd = "11",
                            Number = "12345678"
                        }
                    },
                    PostbackUrl = "http://www.aledsz.com.br/validateRequest.php",
                    SplitRules = new SplitRule[]
                    {
                        new SplitRule()
                        {
                            Recipient = new Recipient()
                            {
                                BankAccount = new BankAccount()
                                {
                                    Conta = "12345",
                                    ContaDv = "0",
                                    Agencia = "1234",
                                    AgenciaDv = "5",
                                    DocumentNumber = "43591017833",
                                    LegalName = "Richard",
                                    ChargeTransferFees = true,
                                    DocumentType = DocumentType.Cpf,
                                    BankCode = "341"
                                }
                            },
                            ChargeProcessingFee = true,
                            Liable = true,
                            Percentage = 100
                        }
                    }
                };

                model.Save();
                model.Capture(3100);
            }
            catch (PagarMeException ex)
            {
                throw ex;
            }
        }

        public Model GetModel()
        {
            return model;
        }
    }
}