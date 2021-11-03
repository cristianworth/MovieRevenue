/*Create and Populate table Studio*/
CREATE TABLE Studio
(
  studio_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(1000) NOT NULL,
);

INSERT INTO Studio VALUES ('20th Century Fox');
INSERT INTO Studio VALUES ('Walt Disney Studios Motion Pictures');
INSERT INTO Studio VALUES ('Universal Pictures');

/*Create and Populate table Movie*/
CREATE TABLE Movie
(
  movie_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  title VARCHAR(1000) NOT NULL,
  year_release INT NULL,
  revenue decimal(15,2) NULL,
  studio_id int FOREIGN KEY REFERENCES Studio(studio_id)
);

INSERT INTO Movie VALUES ('Avatar', 2009, 2847246203, 1);
INSERT INTO Movie VALUES ('Avengers: Endgame', 2019, 2797800564, 2);
INSERT INTO Movie VALUES ('Titanic', 1997, 2201647264, 1);
INSERT INTO Movie VALUES ('Star Wars: The Force Awakens', 2015, 2068223624, 2);
INSERT INTO Movie VALUES ('Avengers: Infinity War', 2018, 2048359754, 2);
INSERT INTO Movie VALUES ('Jurassic World', 2015, 1671713208, 3);
INSERT INTO Movie VALUES ('The Lion King', 2019, 1656943394, 2);
INSERT INTO Movie VALUES ('Marvels The Avengers', 2012, 1518812988, 2);
INSERT INTO Movie VALUES ('Furious 7', 2015, 1516045911, 3);
INSERT INTO Movie VALUES ('Frozen II', 2019, 1450026933, 2);

