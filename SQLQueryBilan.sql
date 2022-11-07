--select numcompte, SUM(montantdebit), SUM(montantcredit), SUM(montantdebit)-SUM(montantcredit) as Solde
--From OperationCompte, Operation
--where Operation.idoperation = OperationCompte.idoperation and
--date_operation between '01/01/2022' and '31/12/2022'
--group by numcompte

--select numcompte, debit, credit, debit-credit as Solde
--From Compte
--where debit + credit <> 0