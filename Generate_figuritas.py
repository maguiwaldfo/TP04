import os

jugadores = [
# Argentina
("messi.svg", "LIONEL MESSI", "10", "ARGENTINA", "#75AADB"),
("emiliano.svg", "EMILIANO MARTÍNEZ", "23", "ARGENTINA", "#75AADB"),
("romero.svg", "CRISTIAN ROMERO", "13", "ARGENTINA", "#75AADB"),
("enzo.svg", "ENZO FERNÁNDEZ", "24", "ARGENTINA", "#75AADB"),
("julian.svg", "JULIÁN ÁLVAREZ", "9", "ARGENTINA", "#75AADB"),

# Brasil
("vinicius.svg", "VINICIUS JUNIOR", "7", "BRASIL", "#FFDD00"),
("alisson.svg", "ALISSON BECKER", "1", "BRASIL", "#FFDD00"),
("marquinhos.svg", "MARQUINHOS", "4", "BRASIL", "#FFDD00"),
("bruno.svg", "BRUNO GUIMARÃES", "8", "BRASIL", "#FFDD00"),
("rodrygo.svg", "RODRYGO", "10", "BRASIL", "#FFDD00"),

# Francia
("mbappe.svg", "KYLIAN MBAPPÉ", "10", "FRANCIA", "#0055A4"),
("maignan.svg", "MIKE MAIGNAN", "16", "FRANCIA", "#0055A4"),
("saliba.svg", "WILLIAM SALIBA", "17", "FRANCIA", "#0055A4"),
("tchouameni.svg", "TCHOUAMÉNI", "8", "FRANCIA", "#0055A4"),
("dembele.svg", "DEMBÉLÉ", "11", "FRANCIA", "#0055A4"),

# España
("pedri.svg", "PEDRI", "8", "ESPAÑA", "#DD0032"),
("unai.svg", "UNAI SIMÓN", "23", "ESPAÑA", "#DD0032"),
("lenormand.svg", "LE NORMAND", "3", "ESPAÑA", "#DD0032"),
("rodri.svg", "RODRI", "16", "ESPAÑA", "#DD0032"),
("lamine.svg", "LAMINE YAMAL", "19", "ESPAÑA", "#DD0032"),

# Alemania
("musiala.svg", "JAMAL MUSIALA", "10", "ALEMANIA", "#000000"),
("terstegen.svg", "TER STEGEN", "1", "ALEMANIA", "#000000"),
("rudiger.svg", "ANTONIO RÜDIGER", "2", "ALEMANIA", "#000000"),
("kimmich.svg", "JOSHUA KIMMICH", "6", "ALEMANIA", "#000000"),
("havertz.svg", "KAI HAVERTZ", "7", "ALEMANIA", "#000000"),
]


template = '''<svg width="200" height="280" xmlns="http://www.w3.org/2000/svg">
  <defs>
    <linearGradient id="grad-{id}" x1="0%" y1="0%" x2="0%" y2="100%">
      <stop offset="0%" style="stop-color:{color};stop-opacity:1" />
      <stop offset="100%" style="stop-color:#ffffff;stop-opacity:1" />
    </linearGradient>
  </defs>
  <rect width="200" height="280" fill="url(#grad-{id})" stroke="#333" stroke-width="3" rx="10"/>
  <rect x="10" y="10" width="180" height="200" fill="#ffffff" opacity="0.3" rx="5"/>
  <text x="100" y="110" font-family="Arial, sans-serif" font-size="22" font-weight="bold" fill="#333" text-anchor="middle">{nombre}</text>
  <text x="100" y="160" font-family="Arial, sans-serif" font-size="48" font-weight="bold" fill="#333" text-anchor="middle">{numero}</text>
  <rect x="10" y="220" width="180" height="50" fill="#ffffff" opacity="0.8" rx="5"/>
  <text x="100" y="245" font-family="Arial, sans-serif" font-size="14" font-weight="bold" fill="#333" text-anchor="middle">{pais}</text>
  <text x="100" y="262" font-family="Arial, sans-serif" font-size="12" fill="#666" text-anchor="middle">Mundial 2026</text>
</svg>'''

base_path = "wwwroot/images/jugadores"

for archivo, nombre, numero, pais, color in jugadores:
    svg_content = template.format(
        id=archivo.replace('.svg', ''),
        nombre=nombre,
        numero=numero,
        pais=pais,
        color=color
    )
    
    file_path = os.path.join(base_path, archivo)
    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(svg_content)
    
    print(f"✓ {archivo}")

print("\n✅ Todas las figuritas generadas exitosamente!")