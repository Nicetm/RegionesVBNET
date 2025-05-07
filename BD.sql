-- INSERT REGIONES (IdRegion se autogenera)
INSERT INTO Region (Region) VALUES
('Arica y Parinacota'),
('Tarapacá'),
('Antofagasta'),
('Atacama'),
('Coquimbo'),
('Valparaíso'),
('Metropolitana'),
('O’Higgins'),
('Maule'),
('Ñuble'),
('Biobío'),
('La Araucanía'),
('Los Ríos'),
('Los Lagos'),
('Aysén'),
('Magallanes');

-- INSERT COMUNAS (al menos 2 por región con XML adicional)
INSERT INTO Comuna (IdRegion, Comuna, InformacionAdicional) VALUES
(1, 'Arica', '<Info><Superficie>4799.4</Superficie><Poblacion Densidad="51.6">247552</Poblacion></Info>'),
(1, 'Putre', '<Info><Superficie>5900</Superficie><Poblacion Densidad="0.5">2000</Poblacion></Info>'),

(2, 'Iquique', '<Info><Superficie>2293.4</Superficie><Poblacion Densidad="150.2">191468</Poblacion></Info>'),
(2, 'Alto Hospicio', '<Info><Superficie>593.2</Superficie><Poblacion Densidad="215.3">127000</Poblacion></Info>'),

(3, 'Antofagasta', '<Info><Superficie>30000</Superficie><Poblacion Densidad="23.4">402444</Poblacion></Info>'),
(3, 'Calama', '<Info><Superficie>15796</Superficie><Poblacion Densidad="18.1">147886</Poblacion></Info>'),

(4, 'Copiapó', '<Info><Superficie>16000</Superficie><Poblacion Densidad="12.5">158000</Poblacion></Info>'),
(4, 'Vallenar', '<Info><Superficie>7000</Superficie><Poblacion Densidad="9.1">52000</Poblacion></Info>'),

(5, 'La Serena', '<Info><Superficie>1892.8</Superficie><Poblacion Densidad="85.2">250000</Poblacion></Info>'),
(5, 'Coquimbo', '<Info><Superficie>1427.3</Superficie><Poblacion Densidad="110.0">232000</Poblacion></Info>'),

(6, 'Valparaíso', '<Info><Superficie>401.6</Superficie><Poblacion Densidad="200">296655</Poblacion></Info>'),
(6, 'Viña del Mar', '<Info><Superficie>121.6</Superficie><Poblacion Densidad="290">324000</Poblacion></Info>'),

(7, 'Santiago', '<Info><Superficie>22.4</Superficie><Poblacion Densidad="8500">5000000</Poblacion></Info>'),
(7, 'Providencia', '<Info><Superficie>14.4</Superficie><Poblacion Densidad="5400">160000</Poblacion></Info>'),

(8, 'Rancagua', '<Info><Superficie>260.3</Superficie><Poblacion Densidad="150">236000</Poblacion></Info>'),
(8, 'San Fernando', '<Info><Superficie>244.7</Superficie><Poblacion Densidad="100">70000</Poblacion></Info>'),

(9, 'Talca', '<Info><Superficie>231.5</Superficie><Poblacion Densidad="130">201000</Poblacion></Info>'),
(9, 'Curicó', '<Info><Superficie>172.3</Superficie><Poblacion Densidad="110">149000</Poblacion></Info>'),

(10, 'Chillán', '<Info><Superficie>511.2</Superficie><Poblacion Densidad="89.5">180000</Poblacion></Info>'),
(10, 'San Carlos', '<Info><Superficie>324.1</Superficie><Poblacion Densidad="60">63000</Poblacion></Info>'),

(11, 'Concepción', '<Info><Superficie>222.4</Superficie><Poblacion Densidad="280">223000</Poblacion></Info>'),
(11, 'Talcahuano', '<Info><Superficie>145.1</Superficie><Poblacion Densidad="300">250000</Poblacion></Info>'),

(12, 'Temuco', '<Info><Superficie>464.5</Superficie><Poblacion Densidad="120">280000</Poblacion></Info>'),
(12, 'Padre Las Casas', '<Info><Superficie>400.0</Superficie><Poblacion Densidad="80">70000</Poblacion></Info>'),

(13, 'Valdivia', '<Info><Superficie>1015.6</Superficie><Poblacion Densidad="74.5">154000</Poblacion></Info>'),
(13, 'La Unión', '<Info><Superficie>650.0</Superficie><Poblacion Densidad="42.2">40000</Poblacion></Info>'),

(14, 'Puerto Montt', '<Info><Superficie>1672.0</Superficie><Poblacion Densidad="105">245000</Poblacion></Info>'),
(14, 'Osorno', '<Info><Superficie>947.3</Superficie><Poblacion Densidad="94">155000</Poblacion></Info>'),

(15, 'Coyhaique', '<Info><Superficie>7300</Superficie><Poblacion Densidad="6.1">56000</Poblacion></Info>'),
(15, 'Puerto Aysén', '<Info><Superficie>5000</Superficie><Poblacion Densidad="3.2">27000</Poblacion></Info>'),

(16, 'Punta Arenas', '<Info><Superficie>19446</Superficie><Poblacion Densidad="5.4">130000</Poblacion></Info>'),
(16, 'Puerto Natales', '<Info><Superficie>4890</Superficie><Poblacion Densidad="2.3">21000</Poblacion></Info>');
