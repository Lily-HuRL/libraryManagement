
USE library;

INSERT INTO Students (FirstName, LastName, Phone, Email) VALUES
('John', 'Doe', '1234567890', 'john.doe@example.com'),
('Jane', 'Smith', '2345678901', 'jane.smith@example.com'),
('Michael', 'Johnson', '3456789012', 'michael.johnson@example.com'),
('Emily', 'Davis', '4567890123', 'emily.davis@example.com'),
('David', 'Williams', '5678901234', 'david.williams@example.com'),
('Sarah', 'Brown', '6789012345', 'sarah.brown@example.com'),
('James', 'Jones', '7890123456', 'james.jones@example.com'),
('Patricia', 'Garcia', '8901234567', 'patricia.garcia@example.com'),
('Robert', 'Miller', '9012345678', 'robert.miller@example.com'),
('Linda', 'Martinez', '0123456789', 'linda.martinez@example.com');


INSERT INTO Books (Title, Author, Publisher, PublishDate, ISBN, Stock) VALUES
('To Kill a Mockingbird', 'Harper Lee', 'J.B. Lippincott & Co.', '1960-07-11', '9780061120084', 10),
('1984', 'George Orwell', 'Secker & Warburg', '1949-06-08', '9780451524935', 15),
('The Great Gatsby', 'F. Scott Fitzgerald', 'Charles Scribner\'s Sons', '1925-04-10', '9780743273565', 20),
('Pride and Prejudice', 'Jane Austen', 'T. Egerton', '1813-01-28', '9780679783268', 12),
('Moby-Dick', 'Herman Melville', 'Harper & Brothers', '1851-10-18', '9781503280786', 8),
('War and Peace', 'Leo Tolstoy', 'The Russian Messenger', '1869-01-01', '9781400079988', 5),
('The Catcher in the Rye', 'J.D. Salinger', 'Little, Brown and Company', '1951-07-16', '9780316769488', 18),
('The Hobbit', 'J.R.R. Tolkien', 'George Allen & Unwin', '1937-09-21', '9780547928227', 25),
('Brave New World', 'Aldous Huxley', 'Chatto & Windus', '1932-08-01', '9780060850524', 14),
('Crime and Punishment', 'Fyodor Dostoevsky', 'The Russian Messenger', '1866-01-01', '9780486415871', 9),
('The Grapes of Wrath', 'John Steinbeck', 'The Viking Press', '1939-04-14', '9780143039433', 11),
('Jane Eyre', 'Charlotte Brontë', 'Smith, Elder & Co.', '1847-10-16', '9780141441146', 13),
('Wuthering Heights', 'Emily Brontë', 'Thomas Cautley Newby', '1847-12-01', '9780141439556', 7),
('The Odyssey', 'Homer', 'Ancient Greece', '800-01-01', '9780140268867', 20),
('The Brothers Karamazov', 'Fyodor Dostoevsky', 'The Russian Messenger', '1880-01-01', '9780374528379', 10),
('Les Misérables', 'Victor Hugo', 'A. Lacroix, Verboeckhoven & Cie.', '1862-01-01', '9780451419438', 5),
('The Divine Comedy', 'Dante Alighieri', 'Italy', '1320-01-01', '9780142437223', 8),
('The Picture of Dorian Gray', 'Oscar Wilde', 'Lippincott\'s Monthly Magazine', '1890-07-20', '9780141439570', 16),
('Frankenstein', 'Mary Shelley', 'Lackington, Hughes, Harding, Mavor & Jones', '1818-01-01', '9780486282114', 12),
('Dracula', 'Bram Stoker', 'Archibald Constable and Company', '1897-05-26', '9780486411095', 17),
('Don Quixote', 'Miguel de Cervantes', 'Francisco de Robles', '1605-01-16', '9780060934347', 9),
('Madame Bovary', 'Gustave Flaubert', 'Michel Lévy Frères', '1857-01-01', '9780140449129', 11),
('The Catch-22', 'Joseph Heller', 'Simon & Schuster', '1961-11-10', '9781451626650', 13),
('A Tale of Two Cities', 'Charles Dickens', 'Chapman & Hall', '1859-04-30', '9780141439600', 20),
('The Lord of the Rings', 'J.R.R. Tolkien', 'George Allen & Unwin', '1954-07-29', '9780618640157', 24),
('Anna Karenina', 'Leo Tolstoy', 'The Russian Messenger', '1878-01-01', '9780143035008', 8),
('The Sound and the Fury', 'William Faulkner', 'Jonathan Cape and Harrison Smith', '1929-10-07', '9780679732242', 7),
('The Alchemist', 'Paulo Coelho', 'HarperTorch', '1988-05-01', '9780061122415', 18),
('Ulysses', 'James Joyce', 'Shakespeare and Company', '1922-02-02', '9780199535675', 6),
('One Hundred Years of Solitude', 'Gabriel García Márquez', 'Harper & Row', '1967-06-05', '9780060883285', 17),
('The Stranger', 'Albert Camus', 'Librairie Gallimard', '1942-05-01', '9780679720201', 14),
('Lolita', 'Vladimir Nabokov', 'Olympia Press', '1955-09-15', '9780679723164', 12),
('The Iliad', 'Homer', 'Ancient Greece', '762-01-01', '9780140275360', 11),
('The Metamorphosis', 'Franz Kafka', 'Verlag Kurt Wolff', '1915-01-01', '9780553213690', 9),
('Great Expectations', 'Charles Dickens', 'Chapman & Hall', '1861-08-01', '9780141439563', 10),
('Alice\'s Adventures in Wonderland', 'Lewis Carroll', 'Macmillan', '1865-11-26', '9780486275437', 15),
('The Count of Monte Cristo', 'Alexandre Dumas', 'Pétion', '1844-01-01', '9780140449266', 14),
('The Old Man and the Sea', 'Ernest Hemingway', 'Charles Scribner\'s Sons', '1952-09-01', '9780684801223', 11),
('Moby Dick', 'Herman Melville', 'Harper & Brothers', '1851-11-14', '9781503280786', 5),
('The Scarlet Letter', 'Nathaniel Hawthorne', 'Ticknor, Reed & Fields', '1850-03-16', '9780142437261', 8),
('The Hunchback of Notre-Dame', 'Victor Hugo', 'Gosselin', '1831-01-14', '9780140443530', 6),
('The Master and Margarita', 'Mikhail Bulgakov', 'YMCA Press', '1967-11-01', '9780140455465', 13),
('The Sun Also Rises', 'Ernest Hemingway', 'Charles Scribner\'s Sons', '1926-10-22', '9780743297332', 7),
('Fahrenheit 451', 'Ray Bradbury', 'Ballantine Books', '1953-10-19', '9781451673319', 12),
('Of Mice and Men', 'John Steinbeck', 'Covici Friede', '1937-02-06', '9780140177398', 20),
('Slaughterhouse-Five', 'Kurt Vonnegut', 'Delacorte', '1969-03-31', '9780440180296', 9),
('The Road', 'Cormac McCarthy', 'Alfred A. Knopf', '2006-09-26', '9780307387899', 11),
('Catch-22', 'Joseph Heller', 'Simon & Schuster', '1961-11-10', '9781451626650', 14),
('The Bell Jar', 'Sylvia Plath', 'Heinemann', '1963-01-14', '9780060837020', 8),
('Gone with the Wind', 'Margaret Mitchell', 'Macmillan Publishers', '1936-06-30', '9780684830681', 18),
('The Handmaid\'s Tale', 'Margaret Atwood', 'McClelland & Stewart', '1985-09-01', '9780385490818', 7),
('Heart of Darkness', 'Joseph Conrad', 'Blackwood\'s Magazine', '1899-11-01', '9780141441672', 9),
('The Book Thief', 'Markus Zusak', 'Picador', '2005-09-01', '9780375842206', 16),
('Beloved', 'Toni Morrison', 'Alfred A. Knopf', '1987-09-01', '9781400033415', 7),
('The Shining', 'Stephen King', 'Doubleday', '1977-01-28', '9780307743657', 12),
('Dune', 'Frank Herbert', 'Chilton Books', '1965-08-01', '9780441013593', 15),
('The Kite Runner', 'Khaled Hosseini', 'Riverhead Books', '2003-05-29', '9781594480003', 13),
('Memoirs of a Geisha', 'Arthur Golden', 'Knopf', '1997-09-23', '9780679781584', 10),
('The Girl with the Dragon Tattoo', 'Stieg Larsson', 'Norstedts Förlag', '2005-08-01', '9780307454546', 9),
('The Brief Wondrous Life of Oscar Wao', 'Junot Díaz', 'Riverhead Books', '2007-09-06', '9781594483295', 14),
('Life of Pi', 'Yann Martel', 'Knopf Canada', '2001-09-11', '9780156027328', 11),
('The Fault in Our Stars', 'John Green', 'Dutton Books', '2012-01-10', '9780525478812', 12),
('The Time Traveler\'s Wife', 'Audrey Niffenegger', 'MacAdam/Cage', '2003-07-05', '9781931561648', 10),
('The Lovely Bones', 'Alice Sebold', 'Little, Brown and Company', '2002-08-06', '9780316168816', 7),
('Room', 'Emma Donoghue', 'Picador', '2010-09-13', '9780316223232', 14),
('The Night Circus', 'Erin Morgenstern', 'Doubleday', '2011-09-13', '9780385534635', 9),
('Water for Elephants', 'Sara Gruen', 'Algonquin Books', '2006-05-26', '9781565125605', 7),
('The Immortal Life of Henrietta Lacks', 'Rebecca Skloot', 'Crown Publishing Group', '2010-02-02', '9781400052188', 10),
('The Hunger Games', 'Suzanne Collins', 'Scholastic Press', '2008-09-14', '9780439023481', 17),
('Divergent', 'Veronica Roth', 'HarperCollins', '2011-04-25', '9780062024039', 15),
('The Maze Runner', 'James Dashner', 'Delacorte Press', '2009-10-06', '9780385737950', 14),
('Twilight', 'Stephenie Meyer', 'Little, Brown and Company', '2005-10-05', '9780316160179', 11),
('The Help', 'Kathryn Stockett', 'Amy Einhorn Books', '2009-02-10', '9780399155345', 16),
('The Girl on the Train', 'Paula Hawkins', 'Riverhead Books', '2015-01-13', '9781594633669', 8),
('Gone Girl', 'Gillian Flynn', 'Crown Publishing Group', '2012-06-05', '9780307588371', 7),
('The Goldfinch', 'Donna Tartt', 'Little, Brown and Company', '2013-10-22', '9780316055443', 10);
