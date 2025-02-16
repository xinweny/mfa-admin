from uuid import UUID
from datetime import date, datetime
from pydantic import BaseModel, Field

from app.core.sort import SortOrder
from app.api.membership.constants import MembershipType
from app.api.due.constants import PaymentMethod
from app.api.address.models import Address

class ListMembershipsRequest(BaseModel):
    year_paid: int = Field(ge=1993)
    has_paid: bool | None
    query: str | None
    membership_type: MembershipType | None
    since_from: date | None
    since_to: date | None
    is_active: bool | None
    sort_start_date: SortOrder | None

class ListMembershipsResponse(BaseModel):
    class Member:
        id: UUID
        first_name: str
        last_name: str
 
    class Due:
        id: UUID
        year: int
        amount_paid: int
        payment_method: PaymentMethod
        payment_date: date | None

    id: UUID
    membership_type: MembershipType
    members: tuple[Member]
    address_id: UUID | None
    address: Address | None
    due: Due | None
    start_date: date
    created_at: datetime
    updated_at: datetime | None
    is_active: bool