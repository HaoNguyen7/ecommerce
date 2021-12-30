package r06.mall.JwtParser;

import java.util.List;
import java.util.Map;

import com.auth0.jwt.JWT;
import com.auth0.jwt.exceptions.JWTDecodeException;
import com.auth0.jwt.interfaces.Claim;
import com.auth0.jwt.interfaces.DecodedJWT;

import r06.mall.Constants.RoleConstants;

public class JwtParser {
    public String Id;
    public String email;
    public List<String> role;

    public boolean isAdmin() {
        return role.contains(RoleConstants.Admin);
    }

    public boolean isKhach() {
        return role.contains(RoleConstants.Khach);
    }

    public boolean isTaiXe() {
        return role.contains(RoleConstants.TaiXe);
    }

    public boolean isAuthorized(String Id) {
        return this.Id.toLowerCase().equals(Id.toLowerCase());
    }

    public JwtParser(String token) {
        try {
            token = token.substring(7);

            DecodedJWT jwt = JWT.decode(token);

            Map<String, Claim> claims = jwt.getClaims(); // Key is the Claim name

            Claim claim = claims.get("role");

            role = claim.asList(String.class);

            claim = claims.get("Id");
            Id = claim.asString();

            email = jwt.getSubject();

        } catch (JWTDecodeException exception) {
            // Invalid token
        }
    }

    public String getId() {
        return Id;
    }

    public void setId(String id) {
        Id = id;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public List<String> getRole() {
        return role;
    }

    public void setRole(List<String> role) {
        this.role = role;
    }

}