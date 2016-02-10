namespace Entitas {
    public partial class Entity {
        static readonly ComponentC componentCComponent = new ComponentC();

        public bool isComponentC {
            get { return HasComponent(ComponentIds.ComponentC); }
            set {
                if (value != isComponentC) {
                    if (value) {
                        AddComponent(ComponentIds.ComponentC, componentCComponent);
                    } else {
                        RemoveComponent(ComponentIds.ComponentC);
                    }
                }
            }
        }

        public Entity IsComponentC(bool value) {
            isComponentC = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherComponentC;

        public static IMatcher ComponentC {
            get {
                if (_matcherComponentC == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.ComponentC);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherComponentC = matcher;
                }

                return _matcherComponentC;
            }
        }
    }
}
