# ML - Reclutamiento de Mutantes para Magneto

Con la api de mutant recruiter es posible verificar cuando un humano es mutante si encuentras más de una secuencia de cuatro letras iguales , de forma oblicua, horizontal o vertical, dado un array de string que representan cada fila de una tabla de (NxN) con la secuencia del ADN.

![enter image description here](https://github.com/fernandomajeric/mutant-recruiter/blob/master/docs/Capture.PNG)

Para la solución se realizo una API en Azure: [MutantRecruiterApi](https://mutantrecruiterapi20200706030223.azurewebsites.net)

## Ejecución local

### 1. Instalar Docker

* Para instalar Docker utilizar la siguiente [guia](https://docs.docker.com/get-docker/).

### 2. Descargar Proyecto

* Ejectuar el siguiente comando:

    `git clone https://github.com/aescobar-icc/magneto-api.git`

### 3. Correr la solución utilizando Docker

Correr los siguientes commandos en la carpeta raiz (donde se encuentra el archivo .sln):

`docker-compose build`

`docker-compose up`

Debería poder realizar solicitudes a localhost:5106 para la api una vez que se completen estos comandos.

### 4. Probar la api

### mutant
* Metodo: POST (No idempotente)
* Objetivo: Detectar si un humano es mutante enviando la secuencia de ADN mediante un HTTP POST con un Json el cual tenga el siguiente formato: POST → /mutant/ { "dna ["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"] }
 #### Validaciones: 
* Respetetar el formato de matriz NxN.
* Contener las letras de los String A, C, G y T las cuales representa cada base nitrogenada del ADN. 
* Es mutante, si encuentras más de una secuencia de cuatro letras iguales, de forma oblicua, horizontal o vertical.

### stats
* Metodo: GET (Idempotente)
* Objetivo: Devolver la cantidad de humanos, cantidad de mutantes y el ratio de ambos con el siguiente formato Json { "count_mutant_dna":40, "count_human_dna":100, "ratio":0.4}

## Documentación de la Api

La documentación de la api se encuentra en [swagger](https://mutantrecruiterapi20200706030223.azurewebsites.net/index.html)

![enter image description here](https://github.com/fernandomajeric/mutant-recruiter/blob/master/docs/Capture3.PNG)
