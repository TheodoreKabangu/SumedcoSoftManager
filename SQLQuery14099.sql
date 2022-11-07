select ref, sum(debit - credit) from Compte where categorie = 'U' and ref like 'A%'
group by ref