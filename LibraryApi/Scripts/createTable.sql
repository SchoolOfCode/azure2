CREATE TABLE Books (
    Id BIGSERIAL PRIMARY KEY,
    Title TEXT,
    Author TEXT
);

INSERT INTO
    BOOKS (Title, Author)
VALUES
    ('Harry Potter', 'J. K. Rowling');