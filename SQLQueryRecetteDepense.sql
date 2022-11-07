select RecetteService.idservice, sum(qtevendue) as Qte, prixservice, sum(qtevendue)* prixservice as total 
from Service, RecetteService where Service.idservice = RecetteService.idrecette
group by RecetteService.idservice