Feature: Realizar una busqueda
		

Scenario: El usuario realiza una busqueda por producto
	Given El usuario se encuentra en la pagina principal de Mercado Libre
	When Busca por “Smartphone”
	And Navega hacia la segunda página de resultados
	And Selecciona el tercer ítem de la lista
	Then El ítem está habilitado para comprar