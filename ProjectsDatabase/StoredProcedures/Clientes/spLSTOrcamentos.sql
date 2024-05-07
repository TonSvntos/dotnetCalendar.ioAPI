create or alter procedure dbo.spLSTOrcamentos


as begin
    
    select 
        orcamento
        , pagamento 
        , pagamentoConfirmado

    from dbo.Clientes
    order by DataDoAtendimento

end