# OperacoesNumericas
Projeto de testes relacionados a operações numéricas, especificamente: Identificar múltiplos e números primos.

## Múltiplos:
Para obter os múltiplos de um número, a aplicação "tenta" dividir por números inferiores de forma crescente, iniciando em 2 até um determinado limite.

O limite ajuda a identificar quando não é mais necessário testar as divisões, evitando processamento desnecessário, porquê não há chance de encontrar um novo divisor.

Por exemplo, se analisamos os divisores de 30, o maior divisor a ser analisado é 15. Como sabemos disso?

30 é divisível por 2, cujo resultado é 15. Dessa forma sabemos que 30 também é divisível por 15 sem fazer uma nova tentativa de divisão. Mas não há como 30 ser divisível por um número maior do que 15.

Considere agora, o exemplo do número 91. 

Os divisores são: 1, 7, 13 e 91. Observamos que o menor divisor depois de 1 é 7.
91 dividido por 7 é igual a 13. Desse modo, podemos concluir que não há nenhum outro número >=13 que seja múltiplo de 91.

Portanto, o maior divisor de um número "N", é definido como: o resultado (quociente) da divisão de um número pelo menor divisor.

   MaiorDivisor = (Numero / MenorDivisor)
   
## Primos:

Outra parte do objetivo dessa aplicação é identificar entre os divisores de um número, quais são primos.

Um número primo é aquele que só é divisível por 1 e por ele mesmo (tecnicamente também por -1 e -N, mas aqui só estamos tratando números positivos). 

Com isso, o limite para a tentativa de divisão precisa de uma abordagem mais eficiente para evitar tentativas de divisão acima do limite necessário.

Consultando a internet, encontrei um teorema que estabelece que **esse limite é a raiz quadrada do número analisado**. Ou seja, se um número não for divisível por números maiores que 1 até o limite √(Numero) ele é primo.


