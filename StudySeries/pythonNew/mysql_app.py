import MySQLdb
               #          host          user           passwd          db        charset
db = MySQLdb.connect('210.119.12.52', 'test_usr', 'mysql_p@ssw0rd', 'shopdb', charset='utf8')
cur = db.cursor()
cur.execute('SELECT * FROM producttbl')

while True:
    product = cur.fetchone()
    if not product:
        break

    print(product)

cur.close()
db.close()