package viewresolver;

import org.springframework.boot.web.servlet.error.ErrorController;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
public class MainController implements ErrorController {

    @RequestMapping(value = { "/jsp" }, method = RequestMethod.GET)
    public String testJspView() {
        return "test";
    }

    @RequestMapping(value = { "/thy" }, method = RequestMethod.GET)
    public String testThymeleafView() {
        return "thyy";
    }

    @RequestMapping(value = { "/index" }, method = RequestMethod.GET)
    public String testJspView2() {
        return "jsp";
    }

    @RequestMapping("/error")
    public String handleError() {
        return "error";
    }

    @Override
    public String getErrorPath() {
        return "/thyerr";
    }
}