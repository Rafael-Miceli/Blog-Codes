

import com.newunittestmodel.rafael.newunittestmodel.User;

import org.junit.Test;
import static org.junit.Assert.*;
import static org.hamcrest.core.IsEqual.*;

public class UserTest {

    @Test
    public void should_login_user_successfully() {
        User user = new User();

        String username = "Teste";
        String password = "123456";

        boolean result = user.login(username, password);

        assertThat(result, equalTo(true));
    }
}
