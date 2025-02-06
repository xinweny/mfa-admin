from typing import Optional
from uuid import UUID

from sqlalchemy.orm import Mapped, mapped_column, relationship

from app.database import Base
from app.api.address.constants import Province
from app.api.membership.models import Membership

class Address(Base):
    __tablename__ = 'addresses'
  
    id: Mapped[UUID] = mapped_column(primary_key=True)
    
    line1: Mapped[str]
    line2: Mapped[Optional[str]]
    city: Mapped[str]
    postal_code: Mapped[str]
    province: Mapped[Province]
    
    membership: Mapped[Membership] = relationship(Membership, uselist=False, back_populates='parent')