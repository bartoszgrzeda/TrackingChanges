scripts to run:

CREATE TABLE IF NOT EXISTS public."TestReadModel"
(
    "Id" uuid NOT NULL,
    "Data" jsonb,
    CONSTRAINT "TestReadModel_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TestReadModel"
    OWNER to postgres;

INSERT INTO public."TestReadModel"(
	"Id", "Data")
	VALUES ('4f4cceb7-f601-47d7-9f95-1731f57da535', '{"Id": "4f4cceb7-f601-47d7-9f95-1731f57da535","TestProperty": "initial value"}');
