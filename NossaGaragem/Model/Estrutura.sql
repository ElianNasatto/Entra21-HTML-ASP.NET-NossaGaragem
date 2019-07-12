CREATE TABLE categorias(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100)
);

CREATE TABLE veiculos(
id INT PRIMARY KEY IDENTITY(1,1),
id_categoria INT,

FOREIGN KEY(id_categoria) REFERENCES categorias(id),

modelo VARCHAR(100),
valor DECIMAL(8,2),
);