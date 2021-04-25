### reflection


- X-Ray를 찍는 것. 클래스가 갖고 있는 모든 정보를 런타임이 실행되는 도중에 뜯어보고, 분석을 할 수 있다.
- 만약에 `Monster`라는 클래스가 있고 이 해당 클래스의 구조를 알고 싶다고 할때 `GetType()`을 통해 해당 타입의 정보를 가져올 수 있다.
- `GetType`은 모든 변수들이 상속받는 오브젝트에 구현되어있는 함수 이다.

    ```csharp
        class Monster
        {
            public int hp;
            protected int attack;
            private float speed;

            void Attack() { }

        }

        static void Main(string[] args)
        {
            Monster monster = new Monster();

            Type type = monster.GetType();
            var fields = type.GetFields(System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Instance);

            foreach(FieldInfo field in fields)
            {
                string access = "protected";
                if (field.IsPublic)
                    access = "public";
                else if (field.IsPrivate)
                    access = "private";
                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
            }
        }
    ```




    ```sh
    # 결과
    public Int32 hp
    protected Int32 attack
    private Single speed
    ```


### attribute

- 컴퓨터가 런타임에 체크할 수 있는 주석


    ```csharp
        class Important : System.Attribute
        {
            string message;
            public Important(string message) { this.message = message;  }
        }
        class Monster
        {
            [Important("Very Important")]
            public int hp;
            protected int attack;
            private float speed;

            void Attack() { }

        }

        static void Main(string[] args)
        {
            Monster monster = new Monster();

            Type type = monster.GetType();
            var fields = type.GetFields(System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Instance);

            foreach(FieldInfo field in fields)
            {
                var attributes = field.GetCustomAttributes();

            }
        }
    ```
