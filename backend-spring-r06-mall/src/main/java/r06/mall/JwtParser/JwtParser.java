package r06.mall.JwtParser;

import java.util.Map;

import com.auth0.jwt.JWT;
import com.auth0.jwt.exceptions.JWTDecodeException;
import com.auth0.jwt.interfaces.Claim;
import com.auth0.jwt.interfaces.DecodedJWT;

import r06.mall.Constants.RoleConstants;

public class JwtParser {
    public String Id;
    public String email;
    public String role;

    public boolean isAdmin() {
        return role.equals(RoleConstants.Admin);
    }

    public boolean isKhach() {
        return role.equals(RoleConstants.Khach);
    }

    public boolean isTaiXe() {
        return role.equals(RoleConstants.TaiXe);
    }

    public JwtParser(String token) {
        try {
            token = token.substring(7);
            System.out.println(token);
            DecodedJWT jwt = JWT.decode(token);
            Map<String, Claim> claims = jwt.getClaims(); // Key is the Claim name
            Claim claim = claims.get("role");
            role = claim.toString().replace("\"", "");
            claim = claims.get("Id");
            Id = claim.toString().replace("\"", "");
            email = jwt.getSubject().replace("\"", "");
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

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

}