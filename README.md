# Fluent Builder Pattern

## Description

Ce projet sert de base pour démontrer le concept de "fluent builder" appliqué à la gestion des données utilisées dans les test unitaires.

## Qu'est-ce qu'un "fluent builder"

Le patron fluent builder n'est pas équvalent au pattern connu sous le nom de
 "builder" proposé par Gamma, Helm, Jonhson et Vlissides dans le livre 
"Design pattern, Elements of reusable Object-Oriented software. 
Ce dernier est supporté par une struture de classe et est utilisé pour 
ecapsuler lacréation d'objets complexe.

Le "fluent builder" est utilisé, lui, pour construire un objet par appel 
de méthode au lieu de fournir un constructeur exaustif ou encore 
d'affecter les valeurs directement à des propriété publiques

## Cas d'utilisation

La force de ce patron réside dans le fait qu'on peut construire une représentation 
par défaut d'un objet et modifier itérativement son contenu par une succession
d'appel à des méthode pour le modeler selon notre besoin. 
Cet avantage est très utile dans le cas où nous avons besoins de construire un objet
pour les besoins d'un test unitaire.

En Effet, lors d'un test unitaire nous ne voulons pas surcharger le code avec de
longues initialisations d'objet. Nous volons qu'il soit facile de voir 
les valeurs d'un objet qui sont pertinentes au test en question.

