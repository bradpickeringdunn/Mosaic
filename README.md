# Mosaic

Patterns employed
SOLID
Repository Pattern

From a UI perspective, I went old school as I was pressed for time.
Had I had more time I would have used Angular / knockout for the UI design.
This would have eliminated the need for the view to be refreshed to show the added or removed tasks.

I used Dto's from the DTO project instead of models inside the Web layer as no logic was required.
If logic had been required to display the information on the view I would have created a new model in the web layer and used auto mapper to map the DTO and used the model in the view.

For a "repository" I used a static class.
Had I been given more time I would have hooked this up to a raven db.
The repository pattern would allow any DB to be connected without affecting the code in the other layers.
