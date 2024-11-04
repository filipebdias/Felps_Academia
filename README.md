
# Funcionamento do Trabalho da Academia - AcademiaoUltimo

#Para colocar o banco para funcionar, usei codeFirst. O nome do dataBase é Academia com "A" maiusculo. 

## Visão Geral
O projeto **AcademiaoUltimo** é um sistema de gerenciamento de academia que facilita o registro e gerenciamento de usuários, planos de pagamento, treinos, aulas e pagamentos. O sistema é projetado para ser intuitivo e acessível, com funcionalidades que atendem tanto aos usuários quanto aos administradores.

## Funcionalidades Principais

### 1. Autenticação de Usuários
- **Login com Autenticação Externa**: Os usuários podem se cadastrar e fazer login utilizando suas contas do Google ou Facebook, proporcionando uma experiência de login rápida e segura. Também possui confirmação por e-mail.
- **Área Administrativa**: Administradores têm acesso a uma interface específica que permite gerenciar usuários e dados da academia. O login para acesso administrativo é feito com as credenciais padrão:
  - **Email**: `adm@gmail.com`
  - **Senha**: `Adm123@`

### 2. Gestão de Usuários
- Cada usuário possui um perfil que inclui informações pessoais, como nome, e-mail e idade.
- Os usuários podem ter planos de pagamento associados e realizar pagamentos, que ficam registrados no sistema.

### 3. Planos de Pagamento
- O sistema oferece diferentes planos de pagamento, que podem variar em preço e benefícios. Os usuários podem escolher o plano que melhor atende às suas necessidades.

### 4. Registro de Treinos e Aulas
- Os usuários podem registrar seus treinos, associando-os a aulas específicas que são ministradas por instrutores qualificados.
- Cada aula possui um instrutor designado e pode conter múltiplos treinos.

### 5. Pagamentos
- Os usuários podem realizar pagamentos pelos planos escolhidos, e todos os pagamentos são registrados no sistema, permitindo fácil acompanhamento.

##fluxo de funcionamento
Precisa cadastrar primeiro os 3 planos da academia, depois cadastra os instrutores, depois as aulas e treinos, por fim é feito a compra do plano.

## Tecnologias Utilizadas
- **ASP.NET MVC**: Framework utilizado para o desenvolvimento da aplicação, permitindo a criação de aplicações web dinâmicas.
- **Microsoft SQL Server**: Sistema de gerenciamento de banco de dados utilizado para armazenar todas as informações da academia, como dados de usuários, planos, pagamentos, treinos e aulas.
- **Entity Framework**: ORM (Object-Relational Mapping) utilizado para facilitar a interação entre a aplicação e o banco de dados.
- **Bootstrap**: Biblioteca de front-end que proporciona um design responsivo e atraente para a interface do usuário.
- **JavaScript/jQuery**: Linguagens utilizadas para implementar funcionalidades interativas na aplicação web.

## Conclusão
O sistema **AcademiaoUltimo** visa proporcionar uma experiência completa e satisfatória tanto para os usuários quanto para os administradores, tornando a gestão de academias mais eficiente e acessível. Com suas funcionalidades integradas e uso de tecnologias modernas, o projeto se posiciona como uma solução robusta no mercado 



