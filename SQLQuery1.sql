DROP TABLE CITIES

CREATE TABLE CITIES (
[NAME] nvarchar (25) PRIMARY KEY,
[LABEL] nvarchar (200)
);

INSERT INTO CITIES ([NAME], [LABEL])
VALUES ('Edmonton', 'Cold_weather_warm_people.');
INSERT INTO CITIES ([NAME], [LABEL])
VALUES ('London', 'Large_dense_and_rainy_but_they_have_good_tea!');
INSERT INTO CITIES ([NAME], [LABEL])
VALUES ('Calgary', 'Warmer.');
INSERT INTO CITIES ([NAME], [LABEL])
VALUES ('Singapore', 'Hot_and_humid_but_a_good_tourist_destination.');
INSERT INTO CITIES ([NAME], [LABEL])
VALUES ('Tokyo', 'Lots_of_flashing_lights.');