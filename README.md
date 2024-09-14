# Controle de Estacionamento

## Objetivo

Este projeto tem como objetivo desenvolver um aplicativo simples para o controle de estacionamento, onde os usuários poderão registrar a entrada e a saída de veículos. O cálculo do valor a ser pago será baseado em uma tabela de preços parametrizada com períodos de vigência.

## Funcionalidades

- Registro de entrada e saída de veículos.
- Consulta de valores praticados para o período com base na data de entrada do veículo.
- Cálculo automático do valor a ser pago com base no tempo de permanência.
- Aplicação de regras específicas para cálculo do valor em períodos de permanência curtos ou longos.

## Regras de Negócio

1. **Tabela de Preços**:
   - Os valores do estacionamento são definidos em uma tabela de preços, que possui vigência. Exemplo: os valores são válidos de 01/01/2024 a 31/12/2024.
   - A tabela de preços deve incluir o valor da hora inicial e o valor das horas adicionais.
   
2. **Cobrança de Permanência**:
   - Se o tempo total de permanência no estacionamento for igual ou inferior a 30 minutos, será cobrada metade do valor da hora inicial.
   - Para permanências superiores a 30 minutos, a cobrança segue o valor total da hora inicial e valores das horas adicionais.

3. **Tolerância de Horas Adicionais**:
   - Existe uma tolerância de 10 minutos para cada hora adicional. Por exemplo:
     - Até 30 minutos: R$ 1,00
     - Até 1 hora: R$ 2,00
     - Até 1 hora e 10 minutos: R$ 2,00
     - Até 1 hora e 15 minutos: R$ 3,00
     - Até 2 horas e 5 minutos: R$ 3,00
     - Até 2 horas e 15 minutos: R$ 4,00

4. **Chave de Busca**:
   - A placa do veículo será utilizada como chave para registrar e buscar as informações de entrada e saída.

## Exemplo de Cálculo

1. **Permanência de 25 minutos**:
   - Valor cobrado: metade do valor da hora inicial.

2. **Permanência de 1 hora e 10 minutos**:
   - Valor cobrado: valor da hora inicial + valor da primeira hora adicional (não será cobrado valor adicional pelos 10 minutos).

3. **Permanência de 2 horas e 15 minutos**:
   - Valor cobrado: valor da hora inicial + 2 horas adicionais.

