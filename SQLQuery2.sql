SELECT * FROM Compte WHERE ref_credit LIKE 'BE%' AND ref_debit IS NULL

SELECT * FROM Compte WHERE ref_debit LIKE 'BE%' AND ref_credit IS NULL

SELECT * FROM Compte WHERE ref_debit LIKE 'BE%' AND ref_credit IS NOT NULL

SELECT * FROM Compte WHERE ref_credit LIKE 'BE%' AND ref_debit IS NOT NULL



SELECT * FROM Compte WHERE ref_debit LIKE 'B%' OR ref_credit LIKE 'B%'
