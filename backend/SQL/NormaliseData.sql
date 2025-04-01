USE Movies

INSERT INTO dbo.Genres (
	[Description]
)
SELECT DISTINCT TRIM(GenreSplit.value)
FROM dbo.MoviesRaw
CROSS APPLY STRING_SPLIT(Genre, ',') AS GenreSplit;

INSERT INTO dbo.Movies (
	ReleaseDate,
	Title,
	Overview,
	Popularity,
	VoteCount,
	VoteAverage,
	OriginalLanguage,
	PosterURL
)
SELECT
	ReleaseDate,
	Title,
	Overview,
	Popularity,
	VoteCount,
	VoteAverage,
	OriginalLanguage,
	PosterURL
FROM dbo.MoviesRaw

SELECT
	Id,
	Title,
	TRIM(GenreSplit.value) AS Genre
FROM dbo.MoviesRaw
CROSS APPLY STRING_SPLIT(Genre, ',') AS GenreSplit;

INSERT INTO dbo.GenreMovie (
	GenresId,
	MovieId
)
SELECT *
FROM
(
	SELECT DISTINCT Genre
	FROM (
		SELECT
		Id,
		Title,
		TRIM(GenreSplit.value) AS Genre
	FROM dbo.MoviesRaw
	CROSS APPLY STRING_SPLIT(Genre, ',') AS GenreSplit;
	) G
) MR
INNER JOIN dbo.Movies M ON MR.Title = M.Title
INNER JOIN dbo.Genres G ON MR.Genre = G.[Description];