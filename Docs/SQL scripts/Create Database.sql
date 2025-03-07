-- DROP SCHEMA public;

CREATE SCHEMA public AUTHORIZATION pg_database_owner;

-- DROP SEQUENCE public.activities_id_seq;

CREATE SEQUENCE public.activities_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.activities_list_id_seq;

CREATE SEQUENCE public.activities_list_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.arrangers_id_seq;

CREATE SEQUENCE public.arrangers_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.cities_id_seq;

CREATE SEQUENCE public.cities_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.countries_id_seq;

CREATE SEQUENCE public.countries_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.directions_id_seq;

CREATE SEQUENCE public.directions_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.events_plan_id_seq;

CREATE SEQUENCE public.events_plan_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.experts_id_seq;

CREATE SEQUENCE public.experts_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.genders_id_seq;

CREATE SEQUENCE public.genders_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.members_id_seq;

CREATE SEQUENCE public.members_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.moderator_events_id_seq;

CREATE SEQUENCE public.moderator_events_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.moderators_id_seq;

CREATE SEQUENCE public.moderators_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;-- public.activities_list определение

-- Drop table

-- DROP TABLE public.activities_list;

CREATE TABLE public.activities_list (
	id serial4 NOT NULL,
	name_activity varchar(150) NOT NULL,
	CONSTRAINT activities_list_pkey PRIMARY KEY (id)
);


-- public.cities определение

-- Drop table

-- DROP TABLE public.cities;

CREATE TABLE public.cities (
	id serial4 NOT NULL,
	image varchar(50) NOT NULL,
	city_name varchar(150) NOT NULL,
	CONSTRAINT cities_pkey PRIMARY KEY (id)
);


-- public.countries определение

-- Drop table

-- DROP TABLE public.countries;

CREATE TABLE public.countries (
	id serial4 NOT NULL,
	name_russian varchar(150) NOT NULL,
	name_english varchar(150) NOT NULL,
	code varchar(5) NOT NULL,
	code_two int4 NOT NULL,
	CONSTRAINT countries_pkey PRIMARY KEY (id)
);


-- public.directions определение

-- Drop table

-- DROP TABLE public.directions;

CREATE TABLE public.directions (
	id serial4 NOT NULL,
	name_direction varchar(150) NOT NULL,
	CONSTRAINT directions_pkey PRIMARY KEY (id)
);


-- public.genders определение

-- Drop table

-- DROP TABLE public.genders;

CREATE TABLE public.genders (
	id serial4 NOT NULL,
	gender varchar(20) NOT NULL,
	CONSTRAINT genders_pkey PRIMARY KEY (id)
);


-- public.moderator_events определение

-- Drop table

-- DROP TABLE public.moderator_events;

CREATE TABLE public.moderator_events (
	id serial4 NOT NULL,
	name_event varchar(100) NULL,
	CONSTRAINT moderator_events_pkey PRIMARY KEY (id)
);


-- public.arrangers определение

-- Drop table

-- DROP TABLE public.arrangers;

CREATE TABLE public.arrangers (
	id serial4 NOT NULL,
	fcs varchar(150) NOT NULL,
	email varchar(150) NOT NULL,
	birthdate date NOT NULL,
	id_country int4 NOT NULL,
	phone_number varchar(50) NOT NULL,
	passwd varchar(50) NOT NULL,
	image varchar(20) NOT NULL,
	gender int4 NOT NULL,
	CONSTRAINT arrangers_pkey PRIMARY KEY (id),
	CONSTRAINT arrangers_gender_fkey FOREIGN KEY (gender) REFERENCES public.genders(id),
	CONSTRAINT arrangers_id_country_fkey FOREIGN KEY (id_country) REFERENCES public.countries(id)
);


-- public.events_plan определение

-- Drop table

-- DROP TABLE public.events_plan;

CREATE TABLE public.events_plan (
	id serial4 NOT NULL,
	event_name varchar(250) NOT NULL,
	contestday date NOT NULL,
	countdays int4 NOT NULL,
	idcity int4 NOT NULL,
	image varchar(20) NULL,
	CONSTRAINT events_plan_pkey PRIMARY KEY (id),
	CONSTRAINT events_plan_idcity_fkey FOREIGN KEY (idcity) REFERENCES public.cities(id)
);


-- public.experts определение

-- Drop table

-- DROP TABLE public.experts;

CREATE TABLE public.experts (
	id serial4 NOT NULL,
	fcs varchar(150) NOT NULL,
	gender int4 NOT NULL,
	email varchar(150) NOT NULL,
	birthdate date NOT NULL,
	id_country int4 NOT NULL,
	phone_number varchar(50) NOT NULL,
	direction int4 NOT NULL,
	passwd varchar(50) NOT NULL,
	image varchar(20) NOT NULL,
	CONSTRAINT experts_pkey PRIMARY KEY (id),
	CONSTRAINT experts_direction_fkey FOREIGN KEY (direction) REFERENCES public.directions(id),
	CONSTRAINT experts_gender_fkey FOREIGN KEY (gender) REFERENCES public.genders(id),
	CONSTRAINT experts_id_country_fkey FOREIGN KEY (id_country) REFERENCES public.countries(id)
);


-- public.members определение

-- Drop table

-- DROP TABLE public.members;

CREATE TABLE public.members (
	id serial4 NOT NULL,
	fcs varchar(150) NOT NULL,
	email varchar(150) NOT NULL,
	birthdate date NOT NULL,
	id_country int4 NOT NULL,
	phone_number varchar(50) NOT NULL,
	passwd varchar(50) NOT NULL,
	image varchar(20) NOT NULL,
	gender int4 NOT NULL,
	CONSTRAINT members_pkey PRIMARY KEY (id),
	CONSTRAINT members_gender_fkey FOREIGN KEY (gender) REFERENCES public.genders(id),
	CONSTRAINT members_id_country_fkey FOREIGN KEY (id_country) REFERENCES public.countries(id)
);


-- public.moderators определение

-- Drop table

-- DROP TABLE public.moderators;

CREATE TABLE public.moderators (
	id serial4 NOT NULL,
	fcs varchar(150) NOT NULL,
	gender int4 NOT NULL,
	email varchar(150) NOT NULL,
	birthdate date NOT NULL,
	id_country int4 NOT NULL,
	phone_number varchar(50) NOT NULL,
	direction int4 NOT NULL,
	events int4 NULL,
	passwd varchar(50) NOT NULL,
	image varchar(20) NOT NULL,
	CONSTRAINT moderators_pkey PRIMARY KEY (id),
	CONSTRAINT moderators_direction_fkey FOREIGN KEY (direction) REFERENCES public.directions(id),
	CONSTRAINT moderators_events_fkey FOREIGN KEY (events) REFERENCES public.moderator_events(id),
	CONSTRAINT moderators_gender_fkey FOREIGN KEY (gender) REFERENCES public.genders(id),
	CONSTRAINT moderators_id_country_fkey FOREIGN KEY (id_country) REFERENCES public.countries(id)
);


-- public.activities определение

-- Drop table

-- DROP TABLE public.activities;

CREATE TABLE public.activities (
	id serial4 NOT NULL,
	name_event int4 NOT NULL,
	start_date date NOT NULL,
	countdays int4 NOT NULL,
	activity int4 NOT NULL,
	activityday int4 NOT NULL,
	starttime time NOT NULL,
	moderator int4 NOT NULL,
	expert1 int4 NULL,
	expert2 int4 NULL,
	expert3 int4 NULL,
	expert4 int4 NULL,
	expert5 int4 NULL,
	winner int4 NULL,
	CONSTRAINT activities_pkey PRIMARY KEY (id),
	CONSTRAINT activities_activity_fkey FOREIGN KEY (activity) REFERENCES public.activities_list(id),
	CONSTRAINT activities_expert1_fkey FOREIGN KEY (expert1) REFERENCES public.experts(id),
	CONSTRAINT activities_expert2_fkey FOREIGN KEY (expert2) REFERENCES public.experts(id),
	CONSTRAINT activities_expert3_fkey FOREIGN KEY (expert3) REFERENCES public.experts(id),
	CONSTRAINT activities_expert4_fkey FOREIGN KEY (expert4) REFERENCES public.experts(id),
	CONSTRAINT activities_expert5_fkey FOREIGN KEY (expert5) REFERENCES public.experts(id),
	CONSTRAINT activities_moderator_fkey FOREIGN KEY (moderator) REFERENCES public.moderators(id),
	CONSTRAINT activities_name_event_fkey FOREIGN KEY (name_event) REFERENCES public.events_plan(id),
	CONSTRAINT activities_winner_fkey FOREIGN KEY (winner) REFERENCES public.members(id)
);


