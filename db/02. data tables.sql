INSERT INTO Supplier (TaxId, Name, Email) VALUES
('900123456', 'Importaciones Tekus S.A.', 'contacto@tekus.com'),
('800987654', 'Servicios Andinos Ltda', 'info@andinos.com'),
('901222333', 'Latam Global Corp', 'ventas@latamglobal.com'),
('805666111', 'Tecnologías del Pacífico SAS', 'soporte@tpacifico.com'),
('900555777', 'Soluciones Caribe S.A.', 'caribe@soluciones.com'),
('902111444', 'Proveedor Maya Inc', 'contacto@maya.com'),
('803333222', 'Servicios Patagónicos SRL', 'info@patagonicos.com'),
('900888999', 'Andes Digital SAS', 'contacto@andesdigital.com'),
('804444555', 'ConoSur Proveedores SA', 'ventas@conosur.com'),
('899111222', 'Amazonía TI SAS', 'contacto@amazoniati.com');
GO

INSERT INTO [Service] (SupplierId, Name, HourlyRate) VALUES
(1, 'Descarga espacial de contenidos', 120.00),
(1, 'Monitoreo satelital', 85.00),
(2, 'Soporte técnico remoto', 40.00),
(2, 'Infraestructura en la nube', 95.00),
(3, 'Servicios de ciberseguridad', 110.00),
(3, 'Integración de APIs', 70.00),
(4, 'Despliegue de microservicios', 130.00),
(4, 'Consultoría DevOps', 150.00),
(5, 'Instalación de redes', 60.00),
(5, 'Cableado estructurado', 45.00),
(6, 'Servicios de localización GPS', 55.00),
(7, 'Monitoreo climático', 80.00),
(8, 'Desarrollo de software a medida', 90.00),
(9, 'Optimización de bases de datos', 100.00),
(10, 'Consultoría TI avanzada', 140.00);
GO

INSERT INTO Country (Name, Code) VALUES
('Colombia', 'CO'),
('Argentina', 'AR'),
('México', 'MX'),
('Chile', 'CL'),
('Perú', 'PE'),
('Brasil', 'BR'),
('Ecuador', 'EC'),
('Uruguay', 'UY'),
('Paraguay', 'PY'),
('Bolivia', 'BO'),
('Estados Unidos', 'US'),
('Canadá', 'CA'),
('Panamá', 'PA'),
('Costa Rica', 'CR'),
('Venezuela', 'VE');
GO

INSERT INTO ServiceCountry (ServiceId, CountryId) VALUES
(1, 1), (1, 3), (1, 11),
(2, 1), (2, 14),
(3, 2), (3, 1),
(4, 11), (4, 12),
(5, 3), (5, 5),
(6, 1), (6, 7),
(7, 11), (7, 12),
(8, 1), (8, 4),
(9, 1), (9, 2),
(10, 2), (10, 4),
(11, 3), (11, 1),
(12, 12), (12, 11),
(13, 1), (13, 5),
(14, 1), (14, 11),
(15, 1), (15, 3);
GO

INSERT INTO SupplierAttribute (SupplierId, AttributeName, AttributeValue) VALUES
(1, 'Sector', 'Tecnología Satelital'),
(1, 'Certificación', 'ISO 9001'),
(2, 'Ubicación', 'Bogotá'),
(3, 'Idiomas Soportados', 'Español, Inglés'),
(4, 'Años de Experiencia', '12'),
(5, 'Región', 'Caribe'),
(6, 'Disponibilidad', '24/7'),
(7, 'Especialidad', 'Monitoreo Ambiental'),
(8, 'Infraestructura', 'Nube Híbrida'),
(9, 'Tamaño de Equipo', '25 Profesionales'),
(1, 'Teléfono', '+57 601 4567890'),
(1, 'País de Operación Principal', 'Colombia'),
(2, 'Horario de Atención', 'Lunes a Viernes 8am - 6pm'),
(2, 'Certificación', 'ISO 27001'),
(3, 'Soporte Emergencias', 'Sí'),
(3, 'Tiempo de Respuesta', 'Menos de 2 horas'),
(4, 'Tipo de Servicios', 'DevOps y Microservicios'),
(4, 'Modalidad Trabajo', 'Remoto / Híbrido'),
(5, 'Cobertura', 'Caribe y Andina'),
(5, 'Latencia Promedio', '30ms'),
(6, 'Plataforma GPS', 'UbiTrack'),
(6, 'Tecnología Principal', 'GPS + GLONASS'),
(7, 'Instrumentos de Medición', 'Sensores Atmosféricos Avanzados'),
(7, 'Registros Históricos', 'Más de 10 años'),
(8, 'Metodología Desarrollo', 'Scrum'),
(8, 'Nivel de Madurez DevOps', 'Alto'),
(9, 'Base de Datos Preferida', 'SQL Server'),
(9, 'Tasa de Disponibilidad', '99.8%'),
(10, 'Clientes Relevantes', 'Empresas FinTech'),
(10, 'Consultores Certificados', 'Sí');
GO